    <system.web>
       <sanitizer defaultProvider="AntiXssSanitizerProvider">
        <providers>
          <add name="AntiXssSanitizerProvider"   type="AjaxControlToolkit.Sanitizer.HtmlAgilityPackSanitizerProvider" />
        </providers>
      </sanitizer>
  
