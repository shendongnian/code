    // explicit Library1.Content to Library2.Content conversion operator
    public static explicit operator Content(Library1.Content content) {
        return new Library1.Content {
           a = content.a,
           b = content.b
        };
    }
