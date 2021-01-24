C#
public class DGItem {
    public String NickName { get; set; }
    public String Code { get; set; }
    public String TypeOfBranch { get; set; }
}
Now create those in your query instead of anonymous objects:
C#
var query = (from sc in cd.SubjectTeachers
             join s in cd.Subjects on sc.IdSubject equals s.Id
             join t in cd.Teachers on sc.IdTeacher equals t.Id
             join b in cd.Branches on sc.IdBranch equals b.Id
             select new DGItem { 
                 NickName = t.NickName, 
                 Code = s.Code, 
                 TypeOfBranch = b.TypeOfBranch 
             }).ToList();
PlanDG.ItemsSource = query;
Now you can cast SelectedItem to a proper type, and make use of it:
C#
DGItem dataRow = (DGItem)PlanDG.SelectedItem;
string cellValue = dataRow.NickName;
