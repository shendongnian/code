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
