    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <Title>Try Catch</Title>
          <Shortcut>try</Shortcut>
          <Description>Places a try catch block with My API error handling</Description>
          <Author>Nathan Freeman-Smith</Author>
        </Header>
        <Snippet>
          <Code Language="csharp"><![CDATA[            try
                {
    
                }
                catch ( Exception ex )
                {
                    My.API.ErrorHandler.Handler.HandleError( ex, System.Reflection.MethodBase.GetCurrentMethod().Name, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName );
                }]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
