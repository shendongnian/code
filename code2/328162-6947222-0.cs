    using System.Linq;
    ....
    var status = lstFiltro.Items.Where(s => s.Selected)
                                .Select(s => Convert.ToInt32(s.Value)
                                .ToArray();
