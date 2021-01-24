    using PX.Data;
    using PX.Objects.CS;
    using PX.Objects.SO;
    using PX.SM;
    using System.Drawing;
    using System.IO;
    namespace PX.RotateUPSLabelImage.Ext
    {
        public class SOShipmentEntryRotateGIFLabelExt : PXGraphExtension<SOShipmentEntry>
        {
            public delegate void ShipPackagesBaseDelegate(SOShipment shiporder);
            [PXOverride]
            public void ShipPackages(SOShipment shiporder, ShipPackagesBaseDelegate BaseInvoke)
            {
                #region Custom-code-to-rotate-retrieved-Label
                //Identify specified Ship-Via/Carrier Shipment is working with
                var carrier = Carrier.PK.Find(Base, shiporder.ShipVia);
                //If specified Ship-Via/Carrier is API/Plug-In based
                if (carrier?.IsExternal == true)
                {
                    //Identify Connected Carrier Plug-In 
                    var plugin = CarrierPlugin.PK.Find(Base, carrier.CarrierPluginID);
                    //If Plug-In is working with UPS
                    if (plugin?.PluginTypeName?.Trim() == typeof(PX.UpsCarrier.UpsCarrier).FullName)
                    {
                        PXGraph.InstanceCreated.AddHandler<UploadFileMaintenance>((fileGraph) =>
                        {
                            fileGraph.RowInserted.AddHandler<UploadFileRevision>((sender, e) =>
                            {
                                UploadFile fileInfo = (UploadFile)sender.Graph.Caches<UploadFile>()?.Current;
                                if (fileInfo != null)
                                {
                                    if (fileInfo.Name.StartsWith("Label #") && (fileInfo.Extansion.ToUpper() == "GIF"))
                                    {
                                        UploadFileRevision fileData = (UploadFileRevision)e.Row;
                                        using (MemoryStream fileMemoryStream = new MemoryStream(fileData?.Data))
                                        {
                                            Image labelImage = Image.FromStream(fileMemoryStream);
                                            if (labelImage != null)
                                            {
                                                labelImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                                ImageConverter imgConverter = new ImageConverter();
                                                fileData.Data = (byte[])imgConverter.ConvertTo(labelImage, typeof(byte[]));
                                            }
                                        }
                                    }
                                }
                            });
                        });
                    }
                }
                #endregion
                //Invoke base method 
                BaseInvoke(shiporder);
            }
        }
    }
