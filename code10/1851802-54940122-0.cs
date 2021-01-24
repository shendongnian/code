    public class MSAccessFixtureBase {
        public MSAccessFixtureBase(bool sharedConnection) {
            // ...
        }
    }
    public class MSAccessFixture : MSAccessFixtureBase {
        public MSAccessFixture() : base(false) { }
    }
    public class MSAccessFixture1Connection : MSAccessFixtureBase {
        public MSAccessFixture1Connection() : base(true) { }
    }
    public abstract class MSAccessBase {
        private MSAccessFixtureBase fixture;
        public MSAccessBase(MSAccessFixtureBase fixture) {
            this.fixture = fixture;
            // ...
        }
    }
    public class MSAccess : MSAccessBase, IClassFixture<MSAccessFixture> {
        public MSAccess(MSAccessFixture fixture) : base(fixture) { }
    }
    public class MSAccess1Connection : MSAccessBase, IClassFixture<MSAccessFixture1Connection> {
        public MSAccess1Connection(MSAccessFixture1Connection fixture) : base(fixture) { }
    }
