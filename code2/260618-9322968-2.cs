    using System;
    using Microsoft.Office.Interop.Outlook;
    using Application = Microsoft.Office.Interop.Outlook.Application;
    namespace RyanCore
    {
        public class Loader
        {
            public static ContactsViewModel LoadModel(Application objOutlook)
            {
                var viewModel = new ContactsViewModel();
                MAPIFolder fldContacts = objOutlook.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                foreach (object obj in fldContacts.Items)
                {
                    if (obj is _ContactItem)
                    {
                        var contact = (_ContactItem) obj;
                        viewModel.Contacts.Add(new Contact(contact.FirstName + " " + contact.LastName, contact.Email1Address));
                    }
                    else if (obj is DistListItem)
                    {
                        var distListItem = (DistListItem) obj;
                        var contactGroup = new ContactGroup(distListItem.Subject);
                        viewModel.Groups.Add(contactGroup);
                        for (Int32 i = 1; i <= distListItem.MemberCount; i++)
                        {
                            Recipient subMember = distListItem.GetMember(i);
                            contactGroup.Contacts.Add(new Contact(subMember.Name, subMember.AddressEntry.Address));
                        }
                    }
                }
                return viewModel;
            }
        }
    }
