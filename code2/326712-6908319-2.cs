    public class Statuses : Chara{
        public static Action<Pokemon> para =
            (pokemonInstance) => { pokemonInstance.Health -= 10; };
    }
    Action<Pokemon>[] statuses = new Action<Pokemon>[]{
        Statuses.para
    };
