    exec [createCode] @TableName='book',@templet =' 
         public @ColumnType @ColumnName ; // @ColumnDesc  
    	 public @ColumnType get@ColumnName()
    	 {
    	    return this.@ColumnName;
    	 }
    	 public void set@ColumnName(@ColumnType @ColumnName)
    	 {
    	    this.@ColumnName=@ColumnName;
    	 }
    	 
    	 '
    	  
