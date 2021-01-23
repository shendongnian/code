    using System.Security.Principal;  // here is the security namespace you need
    ...
    string userName = WindowsIdentity.GetCurrent().Name.Replace("\\", "|");
    string[] split = userName.Split(new Char[] { '|' });
    lblDebug.Text = (split.Count() > 1) ? split[1] : userName;
