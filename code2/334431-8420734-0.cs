        // generate a pivot table
        var pivot = linqQueryResults.Pivot(
            rowKey => rowKey.DepartmentName,
            columnKey => columnKey.JoiningDate,
            value => value.Sum(emp => emp.Salary),
            "Department",
            new Dictionary<string, Func<GetComplianceForClientCurriculums_Result, object>>()
                {
                    {"DepartmentCode", extraRow => extraRow.DepartmentCode},
                    {"DepartmentManager", extraRow => extraRow.DeptManager}
                }
        );
