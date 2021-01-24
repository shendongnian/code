    <!-- maxRequestLength in kilobytes -->
    <system.web>
    	<httpRuntime maxRequestLength="1000000" />
    </system.web>
    
    <!-- maxAllowedContentLength in bytes -->
    <system.WebServer>
    	<security>
            <requestFiltering>
    	        <requestLimits maxAllowedContentLength="1000000000" />
    	    </requestFiltering>
    	</security>
    </system.WebServer>
