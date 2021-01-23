      // iterating backwards is needed because of .move below
                    for (int i = theRootFolder.Items.Count; i > 0; i--)
                    {
                        Outlook.MailItem mi = (Outlook.MailItem)theRootFolder.Items[i];
                        if (mi != null)
                        {
                            if (!mi.Subject.StartsWith("M1"))
                            {
                                mi.Move(_TRIM_archiveFolder);
                            }
                        }
                    }
