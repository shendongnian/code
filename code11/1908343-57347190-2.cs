    public class ItemsTests
    {
        [Fact]
        public async Task Load_items_passes_the_ronseal_challenge()
        {
            using( IDatabase testDatabase = new FakeDatabase() )
            {
                ItemsViewModel vm = new ItemsViewModel( db );
                Assert.Equal( 0, vm.Items.Count );
                await vm.LoadItemsAsync();
                Assert.Equal( 5, vm.Items.Count );
            }
        }
    }
