    //change old variables to use the new type
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
            Counter();
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
    private void Counter()
    {
        if(Maths.Value == 0 && !Maths.Dirty)
        {
            Maths.Dirty = true;
            t++;
        }
        if (English.Value == 0 && !English.Dirty)
        {
            English.Dirty = true;
            t++;
        }
        if(IT.Value == 0 && !IT.Dirty)
        {
            IT.Dirty = true;
            t++;
        }
        if(Construction.Value == 0 && !Construction.Dirty)
        {
            Construction.Dirty = true;
            t++;
        }
    }
