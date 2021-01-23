        // => privilege = new Privilege("SeCreateGlobalPrivilege");
        Type privilegeType = Type.GetType("System.Security.AccessControl.Privilege");
        object privilege = Activator.CreateInstance(privilegeType, "SeCreateGlobalPrivilege");
        // => privilege.Enable();
        privilegeType.GetMethod("Enable").Invoke(privilege, null);
        // =>  privilege.Revert();
        privilegeType.GetMethod("Revert").Invoke(privilege, null);
