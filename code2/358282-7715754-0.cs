    class JsonObj // this class represents the main JSON object { ... }
    {
        public WorkspacesJson workspaces { get;set; }
    }
    class WorkspacesJson // this class represents the workspaces JSON object "workspaces": { ... }
    {
        public List<WorkspaceJson> workspace { get;set; } // this represents the JSON array "workspace": [ ... ]
    }
    class WorkspaceJson // this represents the name/value pair for the workspace JSON array { "name": ..., "href": ... }
    {
        public string name { get;set; }
        public string href { get;set; }
    }
