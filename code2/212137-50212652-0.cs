    // Version 1
    public static class TopologicalSorter<T> where T : class {
        public struct Item {
            public readonly T Object;
            public readonly T Dependency;
            public Item(T @object, T dependency) {
                Object = @object;
                Dependency = dependency;
            }
        }
        public static T[] Sort(T[] objects, Func<T, T, bool> isDependency) {
            return Sort( objects.ToList(), isDependency ).ToArray();
        }
        public static T[] Sort(T[] objects, Item[] dependencies) {
            return Sort( objects.ToList(), dependencies.ToList() ).ToArray();
        }
        private static List<T> Sort(List<T> objects, Func<T, T, bool> isDependency) {
            return Sort( objects, GetDependencies( objects, isDependency ) );
        }
        private static List<T> Sort(List<T> objects, List<Item> dependencies) {
            var result = new List<T>( objects.Count );
            while (objects.Any()) {
                var obj = GetIndependentObject( objects, dependencies );
                RemoveObject( obj, objects, dependencies );
                result.Add( obj );
            }
            return result;
        }
        private static List<Item> GetDependencies(List<T> objects, Func<T, T, bool> isDependency) {
            var dependencies = new List<Item>();
            for (var i = 0; i < objects.Count; i++) {
                var obj1 = objects[i];
                for (var j = i + 1; j < objects.Count; j++) {
                    var obj2 = objects[j];
                    if (isDependency( obj1, obj2 )) dependencies.Add( new Item( obj1, obj2 ) ); // obj2 is dependency of obj1
                    if (isDependency( obj2, obj1 )) dependencies.Add( new Item( obj2, obj1 ) ); // obj1 is dependency of obj2
                }
            }
            return dependencies;
        }
        private static T GetIndependentObject(List<T> objects, List<Item> dependencies) {
            foreach (var item in objects) {
                if (!GetDependencies( item, dependencies ).Any()) return item;
            }
            throw new Exception( "Circular reference found" );
        }
        private static IEnumerable<Item> GetDependencies(T obj, List<Item> dependencies) {
            return dependencies.Where( i => i.Object == obj );
        }
        private static void RemoveObject(T obj, List<T> objects, List<Item> dependencies) {
            objects.Remove( obj );
            dependencies.RemoveAll( i => i.Object == obj || i.Dependency == obj );
        }
    }
    // Version 2
    public class TopologicalSorter {
        public static T[] Sort<T>(T[] source, Func<T, T, bool> isDependency) {
            var list = new LinkedList<T>( source );
            var result = new List<T>();
            while (list.Any()) {
                var obj = GetIndependentObject( list, isDependency );
                list.Remove( obj );
                result.Add( obj );
            }
            return result.ToArray();
        }
        private static T GetIndependentObject<T>(IEnumerable<T> list, Func<T, T, bool> isDependency) {
            return list.First( i => !GetDependencies( i, list, isDependency ).Any() );
        }
        private static IEnumerable<T> GetDependencies<T>(T obj, IEnumerable<T> list, Func<T, T, bool> isDependency) {
            return list.Where( i => isDependency( obj, i ) ); // i is dependency of obj
        }
    }
