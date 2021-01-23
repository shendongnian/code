            <behavior name="serviceBehavior" >
          <serviceAuthorization principalPermissionMode="UseAspNetRoles"roleProviderName="CustomRolesProvider" />
          <serviceCredentials>
            <userNameAuthentication customUserNamePasswordValidatorType ="AspNetUsernamePasswordValidator [Fully qualified name]" userNamePasswordValidationMode="Custom" />
          </serviceCredentials>
