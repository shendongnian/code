            foreach (string id in res)
                    {
                        sbTheOr.Append(',');
                        Guid guid = new Guid(id);
                        sbTheOr.AppendFormat("Convert('{0}','System.Guid')",guid);
                    }
                    if (sbTheOr.Length > 0)
                    {
                        // remove the first ,
                        sbTheOr.Remove(0, 1);
                        queryBuilder.AppendFormat(" and ItemID in ({0})",sbTheOr.ToString());
                    }
