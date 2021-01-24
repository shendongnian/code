    foreach (var edmProperty in simpleProperties) // <-- Original foreach statement
            {
                if(edmProperty.Nullable == false)
                {
                #>    [Required]
    <#
                }
                if(edmProperty.MaxLength != null)
                {
                #>    [StringLength(<#=edmProperty.MaxLength#>)]
    <#
                }
    //Rest of the auto-generated code...
