    public void dumpTables(ProjectFile file)
    {
        List tables = file.getTables();
        Iterator iter = tables.iterator();
        while (iter.hasNext())
        {
            Table table = (Table)iter.next();
            if (table.getResourceFlag())
            {
                List resources = file.getAllResources();
                Iterator resourceIter = resources.iterator();
                while (resourceIter.hasNext())
                {
                    Resource resource = (Resource)iter.next();
                    List columns = table.getColumns();
                    Iterator columnIter = columns.iterator();
                    while (columnIter.hasNext())
                    {
                        Column column = (Column)columnIter.next();
                        Object columnValue = resource.getCachedValue(column.getFieldType());
                        Console.Write(columnValue);
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                List tasks = file.getAllTasks();
                // etc. as above
            }
        }
    }
