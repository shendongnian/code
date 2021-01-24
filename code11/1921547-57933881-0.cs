    public interface IGithubReleaseModel {
        int DoSomethingYouWant();
    }
    
    internal class GithubReleaseModel : IGithubReleaseModel {
        public int DoSomethingYouWant() {
            return 42;
        }
    }
    
    public static IGithubReleaseModel IsNewVersionExistGithub(string Username, string Repository)
    {
        var model = new GithubReleaseModel();
        ...
        return model;
    }
