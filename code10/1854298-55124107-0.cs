    public static string GetFullyQualifiedXPathToElement(string cssSelector, bool isFullJQuery = false, bool noWarn = false)
            {
    
                if (cssSelector.Contains("$(") && !isFullJQuery) {
    
                    isFullJQuery = true;
    
                }
                string finder_method = @"
                            function getPathTo(element) {
                                if(typeof element == 'undefined') return '';
                                if (element.tagName == 'HTML')
                                    return '/HTML[1]';
                                if (element===document.body)
                                    return '/HTML[1]/BODY[1]';
    
                                var ix= 0;
                                var siblings = element.parentNode.childNodes;
                                for (var i= 0; i< siblings.length; i++) {
                                    var sibling= siblings[i];
                                    if (sibling===element)
                                        return getPathTo(element.parentNode)+'/'+element.tagName+'['+(ix+1)+']';
                                    if (sibling.nodeType===1 && sibling.tagName===element.tagName)
                                        ix++;
                                }
                            }
                ";
                if(isFullJQuery) {
    
                    cssSelector = cssSelector.TrimEnd(';');
                        
                }
                string executable = isFullJQuery ? string.Format("{0} return getPathTo({1}[0]);", finder_method, cssSelector) : string.Format("{0} return getPathTo($('{1}')[0]);", finder_method, cssSelector.Replace("'", "\""));
                string xpath = string.Empty;
                try {
    
                    xpath = BaseTest.Driver.ExecuteJavaScript<string>(executable);
    
                } catch (Exception e) {
    
                    if (!noWarn)  {
    
                        //Warn about failure with custom message.
    
                    }
    
                }
                if (!noWarn && string.IsNullOrEmpty(xpath)) {
    
                    //Warn about failure with custom message.
                    //string.Format("Supplied cssSelector did not point to an element. Selector is \"{0}\".", cssSelector);
    
                }
                return xpath;
    
            }
