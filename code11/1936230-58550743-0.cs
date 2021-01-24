public static IList<T> AppendItems<T>(this IEnumerable<T> options, Action<T> blankFactory, bool appendSeparatorRow = true)
        {
            if (options == null || string.IsNullOrEmpty(Sitecore.Configuration.Settings.GetSetting("RACQ.JoinMembership.Top10CarMakes"))) return options.ToList();
            var topmakes = Sitecore.Configuration.Settings.GetSetting("RACQ.JoinMembership.Top10CarMakes").Split('|').ToList().ConvertAll(d => d.ToLower());
            var filteredMakes = options.Where(x => topmakes.Any(y => y.Contains(x.Code.ToLower()))).ToList();//getting all the makes from the listItems
            if (appendSeparatorRow)
            {
                var separatorListItem = blankFactory();
                filteredMakes.Add(separatorListItem);
            }
            var items = options.ToList();
            items.InsertRange(0, filteredMakes);
            return items;
        }
And then you can use it like so:
var whatever = new List<ListItem>():
 
AppendItems(whatever, () => {
                var separatorListItem = new ListItem("------------------", "------------------", false);
                separatorListItem.Attributes.Add("disabled", "true");
    return separatorListItem;
}, true);
