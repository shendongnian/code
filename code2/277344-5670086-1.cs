        using (EntityMemoDataContext em = new EntityMemoDataContext())
        {
            int getEntity1 = Int16.Parse(Session["EntityIdSelected"].ToString());
            var showMemo = from r in em.EntityMemoVs_1s
                           where r.EntityID == getEntity1
                           select new
                           {
                               r.Memo
                           };
            tbShowNote.Text = String.Join(@"<br />", showMemo);
        }
