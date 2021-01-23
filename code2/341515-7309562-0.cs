    ArrayList a = new ArrayList();
    List<int> lst = new List<int>();
    lst.Add(1);
    lst.Add(3);
    lst.Add(5);
    int fst = (int)lst[0];
    int last = 0;
    for (int i = 0; i < lst.Count; i++)
    {
       last = (int)lst[i];
     }
    for (int k = fst; k <= last; k++)
    {
     if (k == fst | k == last)
       {
       }
     else
     {
        a.Add(k);
        a.Add(" ");
     }
    }
       Label1.Text = "Missing Numbers are" + " " + System.String.Concat(a.ToArray());
