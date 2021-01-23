    Blog blog=  new Blog();
    // Note the fixed length of 19 being used since the max tick value is 19 digits long.
    string rowKeyToUse = string.Format("{0:D19}", 
    		DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
    blog.RowKey = rowKeyToUse;
