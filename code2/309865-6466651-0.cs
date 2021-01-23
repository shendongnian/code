                        objectContext.ClientContacts.AddObject(clientContact);
                        objectContext.SaveChanges();
                        id = clientContact.Id;
                        transaction.Complete();
                    }
