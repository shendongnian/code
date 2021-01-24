                List<int> grp = item.GroupIds != null ? item.GroupIds.Split(',').Select(y => Int32.Parse(y)).ToList() : new List<int>();
                Emp.Add(new EmpFields2WithGroup
                {
                    EmpID = item.ID,
                    Name = item.Name,
                    Cell = item.Cell,
                    grpID = grp
                });
            }
