    public interface ISpawnTrigger<out T>{}
    public interface ISpawnerConfig<out T, S> where T : ISpawnTrigger<S>{}
    public interface ISpawner<out T, S> where T : ISpawnerConfig<ISpawnTrigger<S>, S>{}
    public abstract class SpawnTrigger<T> : ISpawnTrigger<T>{}
    public abstract class SpawnerConfig<T, S> : ISpawnerConfig<T, S> where T : ISpawnTrigger<S>{}
    public abstract class Spawner<T, S> : ISpawner<T, S> where T : ISpawnerConfig<ISpawnTrigger<S>, S>{}
    public class OrbSpawnTrigger : SpawnTrigger<Orb>{}
    public class OrbSpawnerConfig : SpawnerConfig<OrbSpawnTrigger, Orb>{}
    public class OrbSpawner : Spawner<OrbSpawnerConfig, Orb>{}
    public class Orb{}
