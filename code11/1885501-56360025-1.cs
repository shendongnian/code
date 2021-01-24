    private readonly List<RoleEnum> roleInApplications;
    public ScopeAuthorizeAttribute(params RoleEnum[] roleInApplications)
    {
        this.roleInApplications = roleInApplications.toList();
    }
