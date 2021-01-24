    public static GitStatus GetTestGitStatus(GitStatusState state){
                GitStatus myStatus = new GitStatus();
                myStatus.Context = GetTestStatusContext(name, genre);//Context
                myStatus.State = state;//State
    }
