    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using PX.Common;
    using PX.Data;
    using PX.Objects.CS;
    using PX.Objects.CR;
    using PX.Objects.CM;
    using PX.Objects.GL;
    using PX.Objects.AP;
    using PX.Objects.EP;
    using PX.Objects.IN;
    using PX.Objects.FA.Overrides.AssetProcess;
    using PX.Objects;
    using PX.Objects.FA;
    namespace SGLCustomizeProject
    {
        public class AssetMaint_Extension : PXGraphExtension<AssetMaint>
        {
            public virtual void _(Events.FieldUpdated<FALocationHistory, FALocationHistoryExtension.usrKodeArea> e)
            {
                var row = e.Row;
                var ext = row.GetExtension<FALocationHistoryExtension>();
                if (ext.UsrKodeArea != null)
                {
                    e.Cache.SetValue<FALocationHistoryExtension.usrDeskripsiArea>(row, ext.UsrKodeArea);
                    var kodeAreaMaster = PXSelect<KodeAreaMaster,
                                     Where<KodeAreaMaster.roomCD,
                                     Equal<Required<KodeAreaMaster.roomCD>>>>
                                     .Select(Base, ext.UsrKodeArea).First().GetItem<KodeAreaMaster>();
                    e.Cache.SetValueExt<FALocationHistoryExtension.usrDeskripsiArea>(row, kodeAreaMaster.RoomDescription);
                }
            }
            public virtual void _(Events.FieldUpdated<FALocationHistory.buildingID> e)
            {
                var row = e.Row as FALocationHistory;
                var ext = row.GetExtension<FALocationHistoryExtension>();
                if (row.BuildingID != null)
                {
                    if (ext.UsrKodeArea != null)
                    {
                        var kodeAreaMaster = PXSelect<KodeAreaMaster,
                                     Where<KodeAreaMaster.roomCD,
                                     Equal<Required<KodeAreaMaster.roomCD>>>>
                                     .Select(Base, ext.UsrKodeArea).First().GetItem<KodeAreaMaster>();
                        if (row.BuildingID == kodeAreaMaster.BuildingID)
                        {
                            return;
                        }
                        else
                        {
                             e.Cache.SetValueExt<FALocationHistoryExtension.usrKodeArea>(row, null);
                            e.Cache.SetValueExt<FALocationHistoryExtension.usrDeskripsiArea>(row, null);
                        }
                    }
                }
                else
                {
                    e.Cache.SetValueExt<FALocationHistoryExtension.usrKodeArea>(row, null);
                    e.Cache.SetValueExt<FALocationHistoryExtension.usrDeskripsiArea>(row, null);
                }
            }
        }
    }
