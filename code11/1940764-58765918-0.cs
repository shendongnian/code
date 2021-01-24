    public static GitStatus GetTestGitStatus(GitStatusState status){
                GitStatus myStatus = new GitStatus();
                myStatus.Context = GetTestStatusContext(name, genre);//Context
                myStatus.State = status;//Status
    }
