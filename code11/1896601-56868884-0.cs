      //add shared parameter definition
      AddSetOfSharedParameters(rvtDoc);
      //......
      //......
      //add shared parameter to the specific shape
     using (Transaction tx = new Transaction(rvtDoc))
                        {
                            tx.Start("Change P");
                            Element readyDS = rvtDoc.GetElement(roomId);
                            Parameter p = readyDS.LookupParameter("RoomNumber");
                            if (p != null)
                            {
                                p.Set(room.Number.ToString());
                            }
                            tx.Commit();
                        }
