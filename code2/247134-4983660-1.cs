    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public partial class Test : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                BindTagCloud();
            }
    
            public class Race
            {
                public string GrandPrix { get; set; }
                public string TeamWinner { get; set; }
                public int Year { get; set; }
            }
    
            public IEnumerable<Race> GetRaces()
            {
                yield return new Race { GrandPrix = "Australia", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Malaysia", TeamWinner = "Williams-BMW", Year = 2002 };
                yield return new Race { GrandPrix = "Brazil", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "San Marino", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Spain", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Austria", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Monaco", TeamWinner = "McLaren-Mercedes", Year = 2002 };
                yield return new Race { GrandPrix = "Canada", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Europe", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Great Britain", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "France", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Germany", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Hungary", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Belgium", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Italy", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "United States", TeamWinner = "Ferrari", Year = 2002 };
                yield return new Race { GrandPrix = "Japan", TeamWinner = "Ferrari", Year = 2002 };
    
                yield return new Race { GrandPrix = "Australia", TeamWinner = "McLaren-Mercedes", Year = 2003 };
                yield return new Race { GrandPrix = "Malaysia", TeamWinner = "McLaren-Mercedes", Year = 2003 };
                yield return new Race { GrandPrix = "Brazil", TeamWinner = "Jordan-Ford", Year = 2003 };
                yield return new Race { GrandPrix = "San Marino", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Spain", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Austria", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Monaco", TeamWinner = "Williams-BMW", Year = 2003 };
                yield return new Race { GrandPrix = "Canada", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Europe", TeamWinner = "Williams-BMW", Year = 2003 };
                yield return new Race { GrandPrix = "France", TeamWinner = "Williams-BMW", Year = 2003 };
                yield return new Race { GrandPrix = "Great Britain", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Germany", TeamWinner = "Williams-BMW", Year = 2003 };
                yield return new Race { GrandPrix = "Hungary", TeamWinner = "Renault", Year = 2003 };
                yield return new Race { GrandPrix = "Italy", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "United States", TeamWinner = "Ferrari", Year = 2003 };
                yield return new Race { GrandPrix = "Japan", TeamWinner = "Ferrari", Year = 2003 };
            }
    
            private void BindTagCloud()
            {
                int year = 2002;
    
                var tagSummaryNegative = from t in GetRaces()
                                         where t.Year == 2002
                                         group t by t.TeamWinner into tagGroup
                                         select new
                                         {
    
                                             Tag = tagGroup.Key,
                                             tagCount = tagGroup.Count()
    
                                         };
    
                var tagSummaryNegativeIteration = from t in GetRaces()
                                                  where t.Year == 2002
                                                  group t by t.TeamWinner into tagGroup
                                                  select new
                                                  {
    
                                                      Tag = tagGroup.Key,
                                                      tagCount = tagGroup.Count()
    
                                                  };
    
                var tagSummaryPositive = from t in GetRaces()
                                         where t.Year == 2003
                                         group t by t.TeamWinner into tagGroup
                                         select new
                                         {
    
                                             Tag = tagGroup.Key,
                                             tagCount = tagGroup.Count()
    
                                         };
    
                var tagSummaryPositiveIteration = from t in GetRaces()
                                                  where t.Year == 2003
                                                  group t by t.TeamWinner into tagGroup
                                                  select new
                                                  {
    
                                                      Tag = tagGroup.Key,
                                                      tagCount = tagGroup.Count()
    
                                                  };
    
    
                int maxTagFrequencyNegative = (from t in tagSummaryNegative select (int?)t.tagCount).Max() ?? 0;
                int maxTagFrequencyPositive = (from t in tagSummaryPositive select (int?)t.tagCount).Max() ?? 0;
    
                int maxTagFrequencyNegativeIteration = (from t in tagSummaryNegativeIteration select (int?)t.tagCount).Max() ?? 0;
                int maxTagFrequencyPositiveIteration = (from t in tagSummaryPositiveIteration select (int?)t.tagCount).Max() ?? 0;
    
    
                var tagCloudNegative = from t in GetRaces()
                                       where t.Year == 2002
                                       group t by t.TeamWinner into tagGroup
                                       select new
                                       {
    
                                           Tag = tagGroup.Key,
                                           weight = (double)tagGroup.Count() / maxTagFrequencyNegative * 100
                                       };
    
                var tagCloudNegativeIteration = from t in GetRaces()
                                                where t.Year == 2002
                                                group t by t.TeamWinner into tagGroup
                                                select new
                                                {
    
                                                    Tag = tagGroup.Key,
                                                    weight = (double)tagGroup.Count() / maxTagFrequencyNegativeIteration * 100
                                                };
    
                var tagCloudPositive = from t in GetRaces()
                                       where t.Year == 2003
                                       group t by t.TeamWinner into tagGroup
                                       select new
                                       {
    
                                           Tag = tagGroup.Key,
                                           weight = (double)tagGroup.Count() / maxTagFrequencyPositive * 100
                                       };
    
                var tagCloudPositiveIteration = from t in GetRaces()
                                                where t.Year == 2003
                                                group t by t.TeamWinner into tagGroup
                                                select new
                                                {
    
                                                    Tag = tagGroup.Key,
                                                    weight = (double)tagGroup.Count() / maxTagFrequencyPositiveIteration * 100
                                                };
    
                if (year == 2002)
                {
                    ListView1.DataSource = tagCloudNegativeIteration;
                    ListView1.DataBind();
    
                    ListView2.DataSource = tagCloudPositiveIteration;
                    ListView2.DataBind();
    
                }
                else
                {
                    ListView1.DataSource = tagCloudNegative;
                    ListView1.DataBind();
    
                    ListView2.DataSource = tagCloudPositive;
                    ListView2.DataBind();
    
                }
            }
    
            public string GetTagSize(double weight)
            {
    
                if (weight >= 99)
                    return "xx-large";
                else if (weight >= 60)
                    return "x-large";
                else if (weight >= 40)
                    return "large";
                else if (weight >= 20)
                    return "medium";
                else
                    return "small";
            }
        }
    }
