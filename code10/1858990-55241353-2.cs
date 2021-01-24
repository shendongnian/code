    List<DateTime> lb = new List<DateTime>();
            lb.Add(C1.SelectedDate);
            DateTime[] a = lb.ToArray();
            lb.CopyTo(a, 0);
            Session["x"] = a;
            DateTime[] collection = (DateTime[])Session["x"];
            foreach (var item in collection)
            {
                Label1.Text += item.ToShortDateString() + "</br>";
            }
