using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game.Characters;
using Game.Inventory;
namespace Tests
{
    public class ItemTests
    {
        Player player;
        Character character;
        WorldItem worldItem;
        ItemScript itemScript;
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Tests/Player"));
            yield return null; // Wait for prefab to load
            character = player.GetComponent<Character>();
            worldItem = WorldItem.Create(Resources.Load<Item>("Items/item"), 1);
            yield return null; // Wait for prefab to load
            character.Inventory.Give(worldItem);
            itemScript = character.HandItemContainer.gameObject.GetComponentInChildren<ItemScript>();
        }
        
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(player);
            Object.Destroy(character);
            Object.Destroy(ectomodulatorWorldItem);
        }
        [Test]
        public void ItemIsOnHand()
        {
            // Test
            Assert.IsNotNull(itemScript);
        }
        [Test]
        public void ItemIsDisabledAtStart()
        {
            // Test
            Assert.IsFalse(itemScript.IsActive);
        }
    }
}
  [1]: https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-actions-outside-tests.html#unitysetup-and-unityteardown
