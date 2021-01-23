     public partial class selecting_divs_with_linq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //When I get your div value I am going to put it in this list...I don't know what you are going to with it...
            List<double> results = new List<double>(); 
            //First we want to get a list of all of the DIV inside of the container div for my_grid:
            List<System.Web.UI.HtmlControls.HtmlGenericControl> listOfDivs = this.my_grid.Controls.OfType<System.Web.UI.HtmlControls.HtmlGenericControl>().ToList<System.Web.UI.HtmlControls.HtmlGenericControl>();
            //because the array is AxA we need the square root of the count of divs and this gives us the upper range of the array values:
            double A = Math.Sqrt(listOfDivs.Count);
            //these nested for loops extract every value from your grid and puts them into the "results" list
            //of course if you want to do something else with them that works too... see button2_click for an alternative...
            for (double X = 0; X < A; X++)
            {
                for (double Y = 0; Y < A; Y++)
                {
                    string divId = string.Format("cell_{0}_{1}", Y.ToString(), X.ToString());
                    var div = listOfDivs.First(d => d.ID == divId);
                    //now you have 'the div'
                    string dblX = div.InnerText;
                    results.Add(double.Parse(dblX));
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //First we want to get a list of all of the DIV inside of the container div for my_grid:
            List<System.Web.UI.HtmlControls.HtmlGenericControl> listOfDivs = this.my_grid.Controls.OfType<System.Web.UI.HtmlControls.HtmlGenericControl>().ToList<System.Web.UI.HtmlControls.HtmlGenericControl>();
            //because the array is AxA we need the square root of the count of divs and this gives us the upper range of the array values:
            double A = Math.Sqrt(listOfDivs.Count);
            //these nested for loops extract every value from your grid and puts them into the "results" list
            //of course if you want to do something else with them that works too... see button2_click for an alternative...
            for (double X = 0; X < A; X++)
            {
                for (double Y = 0; Y < A; Y++)
                {
                    string divId = string.Format("cell_{0}_{1}", Y.ToString(), X.ToString());
                    var div = listOfDivs.First(d => d.ID == divId);
                    //now you have 'the div'
                    string dblX = div.InnerText;
                    //alternate: update the value of each entry like this:
                    div.InnerHtml = (double.Parse(dblX) / 2).ToString();
                    //now each value gets cut in half
                }
            }
        }
    }
