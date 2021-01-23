    // explicit Library.Content to Library2.Content conversion operator
    public static explicit operator Content(Library.Content content) {
        return new Library2.Content {
           a = content.a,
           b = content.b
        };
    }
