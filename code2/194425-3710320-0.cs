    protected void AddEvent_Click(object sender, EventArgs e)
    {
        Event ev = new Event();
    
        ev.Name = txtName.Text;
        if(Session["events"] == null)
        {
          Session["events"] = new List<Event>();
        }
        var events = (List<Event>)Session["events"];
        events.Add(ev);
    }
