                ListItem item = mEmails[itemcheck];
                if (item is Email)
                {
                    Email email = (Email)mEmails[itemcheck];
                    string subject = email.Subject;
                }
                else if (item is DateNow)
                {
                    DateNow date = (DateNow)mEmails[itemcheck];
                }
                else if (item is DateBefore)
                {
                    DateBefore date = (DateBefore)mEmails[itemcheck];
                }
                else 
                {// the left is DateYesterday
                    DateYesterday date = (DateYesterday)mEmails[itemcheck];
                }
