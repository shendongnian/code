    DataTable dtNew = new DataTable();
    dtNew = q1.CopyToDataTable<DataRow>();
    dtNew.TableName = "DTInv";
    dsInvitee.Tables.Add(dtNew.Copy());
    dsInvitee.AcceptChanges();
