     entity.Property(e => e.MyEnumField)
            .HasMaxLength(50)
            .HasConversion(
                    v => v.ToString(),
                    v => {
    			
    				
    				if(Enum.TryParse(v,true,out var res)){
    				return res;
    				}
    				
    				return MyEnum.Default;
    				
    				})
                   .IsUnicode(false);
