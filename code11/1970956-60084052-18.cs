    var Maths = new Subject();
    var English = new Subject();
    var Construction = new Subject();
    var IT = new Subject();
    Subject[] subjects = {null, Maths, English, Construction, IT};
    int t = 1;
    int c = 0;
    while (t < 4)
    {
        if (Convert.ToInt32(Chart[c].Text) != 0)
        {
            if (c < 12)
            {
                c++;
            }                       
            Counter(subjects);
        }
        else
        {
            int m = random.Next(1, 4);
            Chart[c].Text = Convert.ToString(m);
            subject[m].Value--; 
            Chart[c].Refresh();
            tbTotal--;
        }
    }
    private void Counter(IEnumerable<Subject> subjects)
    {
        foreach(var s in subjects.Where(s => s is object))
        {
           if (s.Value == 0 && !s.Dirty)
           {
               s.Dirty = true;
               t++;
           {
        }
    }
