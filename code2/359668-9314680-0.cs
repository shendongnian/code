    protected override void PerformDataBinding(IEnumerable data)
            {
                var enum1 = data.GetEnumerator();
                int count = 0;
                while (enum1.MoveNext())
                {
                    count++;
                }
                this.TotalRecordCount = count;
    
                base.PerformDataBinding(data);
            }
