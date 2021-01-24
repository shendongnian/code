    public class TheModel
    {
        public Table1Model Table1Model { get; set; }
        public Table2Model Table2Model { get; set; }
    }
    var result = db.Table1Model
        .Where(t => t.Name = request.Name)
        .Select(t => new TheModel {
            Table1Model = t,
            Table2Model = t.Table2Models
                .OrderByDescending(n => n.Table2ModelId)
                .FirstOrDefault())
        .OrderBy(t2 => t2.Table2Model.SpecialData1)
        .Take(5)
        .ToList();
