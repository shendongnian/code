    public class ClassViewModel {
        public Class Class { get; set; }
        public int AttendeeCount { get; set; }
        public int ClassCommentCount { get; set; }
    }
    var viewModel = context.Classes.Select(clas => 
        new ClassViewModel { 
            Class = clas, 
            AttendeeCount = clas.ClassAttendes.Count, 
            ClassCommentCount = clas.ClassComments.Count}
    ).OrderBy(model => model.ClassCommentCount).Skip(startRecord).Take(recordsToReturn).ToList();
