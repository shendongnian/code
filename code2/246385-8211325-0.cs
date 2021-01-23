    <behaviors>
    			<serviceBehaviors>
    				<behavior name="">
    					<serviceMetadata httpGetEnabled="true" />
    					<serviceCredentials>
    						<userNameAuthentication userNamePasswordValidationMode="Custom"
    						                        customUserNamePasswordValidatorType="MyNamespace.MyValidator, MyNamespace" />
    					</serviceCredentials>
    				</behavior>
    			</serviceBehaviors>
    		</behaviors>
