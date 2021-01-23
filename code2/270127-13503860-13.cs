        ax.FullOuterJoin(
                bx, a => a.id, b => b.id, 
                (a, b, id) => new { a.name, b.surname },
                new { id = -1, name    = "(no firstname)" },
                new { id = -2, surname = "(no surname)" }
            )
