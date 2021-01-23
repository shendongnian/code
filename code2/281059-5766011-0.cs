        query.Select(el =>
                         {
                             DataRow row =
                                 table.NewRow();
                             row["ExtraColumn"] = el.Genre;
                             return row;
                         }
            ).CopyToDataTable(table, LoadOption.PreserveChanges);
