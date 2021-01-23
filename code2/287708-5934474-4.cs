&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
&lt;div&gt;This is page to add multiple user controls.&lt;/div&gt;
&lt;p&gt;
	Customer1 Details:&lt;br /&gt;
	&lt;uc1:WebUserControl1 ID=&quot;WebUserControl11&quot; runat=&quot;server&quot; /&gt;
&lt;/p&gt;
&lt;p&gt;
	Customer2 Details:&lt;br /&gt;
	&lt;uc1:WebUserControl1 ID=&quot;WebUserControl12&quot; runat=&quot;server&quot; /&gt;           
&lt;/p&gt;
&lt;asp:Button ID=&quot;Button1&quot; runat=&quot;server&quot; Text=&quot;Continue&quot; OnClick=&quot;GetCustDetails&quot;/&gt;
&lt;asp:Button ID=&quot;Button2&quot; runat=&quot;server&quot; Text=&quot;Clear&quot; CausesValidation=&quot;false&quot; OnClick=&quot;ClearFields&quot; /&gt;&lt;br /&gt;
Customer1 FirstName: &lt;asp:label ID=&quot;Label1&quot; runat=&quot;server&quot;&gt;&lt;/asp:label&gt;&lt;br /&gt;
Customer1 LastName: &lt;asp:label ID=&quot;Label2&quot; runat=&quot;server&quot;&gt;&lt;/asp:label&gt;&lt;br /&gt;
Customer2 FirstName: &lt;asp:label ID=&quot;Label3&quot; runat=&quot;server&quot;&gt;&lt;/asp:label&gt;&lt;br /&gt;
Customer2 LastName: &lt;asp:label ID=&quot;Label4&quot; runat=&quot;server&quot;&gt;&lt;/asp:label&gt;&lt;br /&gt;
&lt;/form&gt;
    
