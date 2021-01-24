        public class SOShipmentEntryRotateGIFLabelExt : PXGraphExtension<SOShipmentEntry>
        {
            public delegate void ShipPackagesBaseDelegate(SOShipment shiporder);
            [PXOverride]
            public void ShipPackages(SOShipment shiporder, ShipPackagesBaseDelegate BaseInvoke)
            {
                #region Custom-code-to-rotate-retrieved-Label
                PXGraph.InstanceCreated.AddHandler<UploadFileMaintenance>((fileGraph) =>
                {
                    fileGraph.RowInserted.AddHandler<UploadFileRevision>((sender, e) =>
                    {
                        UploadFileRevision fileData = (UploadFileRevision)e.Row;
                    });
                });
                #endregion
                //Invoke base method 
                BaseInvoke(shiporder);
            }
        }
