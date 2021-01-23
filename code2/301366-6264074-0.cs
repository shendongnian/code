            dataGridView1.RowDataBound += new GridViewRowEventHandler(dataGridView1_RowDataBound);
    
        void dataGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                var r = Convert.ToInt32(ViewData["RequesterCode"]);
                if (e.Row.DataItem is AC.CCBS.ServiceFactory.AndcWorkFlow.RequestView)
                {
                    var s = e.Row.DataItem as AC.CCBS.ServiceFactory.AndcWorkFlow.RequestView;
                    var r1 = s.RequestCode;
                    e.Row.Attributes.Add("onclick","DoSome(this);");
                }
            }
        }
    
    <script DoSome>
    DoSome=function(sender){
     //do something here
    }
