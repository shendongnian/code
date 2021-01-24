    var xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <root name=""Master"">
    	<Menu name=""Menu One"">
    		<Entry name=""Data One"">
    			<Value>Data goes here</Value>
    		</Entry>
    		<Menu name=""Sub Menu One"">
    			<Entry name=""Sub Data One"">
    				<Value>Data goes here</Value>
    			</Entry>
    		</Menu>
    	</Menu>
    	<Menu name=""Menu Two"">
    		<Entry name=""Data Two"">
    			<Value>Data goes here</Value>
    		</Entry>
    		<Menu name=""Sub Menu Two"">
    			<Entry name=""Sub Data Two"">
    				<Value>Data goes here</Value>
    			</Entry>
    			<Menu name=""Sub Sub Menu Two"">
    				<Entry name=""Sub Sub Data Two"">
    					<Value>Data goes here</Value>
    				</Entry>
    			</Menu>
    		</Menu>
    	</Menu>
    	<Menu name=""Menu Three (no children)"">
    		<Entry name=""Data One"">
    			<Value>Data goes here</Value>
    		</Entry>
    	</Menu>
    	<Menu name=""Menu Four (empty)"">
    	</Menu>
    </root>";
