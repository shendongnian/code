    <#if (!ReferenceEquals(edmProperty.Documentation, null))
    {
    #>
    /// <summary>
    /// <#=edmProperty.Documentation.Summary#> – <#=edmProperty.Documentation.LongDescription#>
    /// </summary>
    <#}#>
