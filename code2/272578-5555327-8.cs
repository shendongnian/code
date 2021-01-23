    1. Create a class which contains all properties you need, and populate them in the constructor
              
            
                   class Student
                   {
                   int _StudentId;
                   public int StudentId {get;}
                   string _Name;
                   public string Name {get;}
                   ...
    
       public Student(int studentId, string name ...)
       { _StudentId = studentId; _Name = name; ... }
      }
    
       
        2. Create an IComparer < Student > class, to be able to sort
           class StudentSorter : IComparer<Student>
           {
             public enum SField {StudentId, Name ... }
             SField _sField; SortOrder _sortOrder;
             public StudentSorder(SField field, SortOrder order)
             { _sField = field; _sortOrder = order;}
             public int Compare(Student x, Student y)
             {
               if (_SortOrder == SortOrder.Descending)
                    {
                        Student tmp = x;
                        x = y;
                        y = tmp;
                    }
                    
                    if (x == null || y == null)
                        return 0;
        
                    int result = 0;
                    switch (_sField)
                    {
                        case SField.StudentId:
                            result = x.StudentId.CompareTo(y.StudentId);
                            break;
                        case SField.Name:
                            result = x.Name.CompareTo(y.Name);
                            break;
                            ...
                    }
        
                    return result;
             }
           }
        3. Within the form containing the datagrid add
           ListDictionary sortOrderLD = new ListDictionary(); //if less than 10 columns
           private SortOrder SetOrderDirection(string column)
                {
                    if (sortOrderLD.Contains(column))
                    {
                        sortOrderLD[column] = (SortOrder)sortOrderLD[column] == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                    }
                    else
                    {
                        sortOrderLD.Add(column, SortOrder.Ascending);
                    }
        
                    return (SortOrder)sortOrderLD[column];
                }
        4. Within datagridview_ColumnHeaderMouseClick event handler do something like this
           private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
                {
                    StudentSorter sorter = null;
                    string column = dGV.Columns[e.ColumnIndex].DataPropertyName; //Use column name if you set it
                    if (column == "StudentId")
                    {
                        sorter = new StudentSorter(StudentSorter.SField.StudentId, SetOrderDirection(column));
                    }
                    else if (column == "Name")
                    {
                        sorter = new StudentSorter(StudentSorter.SField.Name, SetOrderDirection(column));
                    }
                    
                    ...
        
                    List<Student> lstFD = datagridview.DataSource as List<Student>;
                    lstFD.Sort(sorter);
                    datagridview.DataSource = lstFD;
                    datagridview.Refresh();
                }
        
        Hope this helps
