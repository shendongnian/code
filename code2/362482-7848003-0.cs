                IExchangeMailbox exMb = (IExchangeMailbox)userDe.NativeObject;
                IADsSecurityDescriptor securityDescriptor = (IADsSecurityDescriptor)exMb.MailboxRights;
                IADsAccessControlList acl = (IADsAccessControlList)securityDescriptor.DiscretionaryAcl;
                AccessControlEntry ace = new AccessControlEntry();
                ace.Trustee = groupName;
                ace.AccessMask = 1;
                ace.AceFlags = 2;
                ace.AceType = 0;
                acl.AddAce(ace);
                securityDescriptor.DiscretionaryAcl = acl;
                IADsUser iadsUser = (IADsUser)userDe.NativeObject;
                iadsUser.Put("msExchMailboxSecurityDescriptor", securityDescriptor);
   
                iadsUser.SetInfo();  
      
