    public class InGroup
    {
        public string Name { get; set; }
        public bool Current { get; set; }
        public bool Fixe { get; set; }
        public bool Thread { get; set; }
    }
    
    WindowsIdentity current = System.Security.Principal.WindowsIdentity.GetCurrent();
    WindowsPrincipal principalcurrent = new WindowsPrincipal(current);
    
    WindowsIdentity fixe = new WindowsIdentity("JW2031");
    WindowsPrincipal principalFixe = new WindowsPrincipal(fixe);
    
    IPrincipal principalThread = System.Threading.Thread.CurrentPrincipal;
    
    List<InGroup> ingroups = new List<InGroup>();
    foreach (IdentityReference item in current.Groups)
    {
        IdentityReference reference = item.Translate(typeof(NTAccount));
        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            reference.Value,
            principalcurrent.IsInRole(reference.Value),
            principalFixe.IsInRole(reference.Value),
            principalThread.IsInRole(reference.Value));
    
        ingroups.Add(new InGroup()
        {
            Name = reference.Value,
            Current = principalcurrent.IsInRole(reference.Value),
            Fixe = principalFixe.IsInRole(reference.Value),
            Thread = principalThread.IsInRole(reference.Value)
        });
    }
    foreach (IdentityReference item in fixe.Groups)
    {
        IdentityReference reference = item.Translate(typeof(NTAccount));
        if (ingroups.FindIndex(g => g.Name == reference.Value) == -1)
        {
            ingroups.Add(new InGroup()
            {
                Name = reference.Value,
                Current = principalcurrent.IsInRole(reference.Value),
                Fixe = principalFixe.IsInRole(reference.Value),
                Thread = principalThread.IsInRole(reference.Value)
            });
            Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                reference.Value,
                principalcurrent.IsInRole(reference.Value),
                principalFixe.IsInRole(reference.Value),
                principalThread.IsInRole(reference.Value));
        }
    }
