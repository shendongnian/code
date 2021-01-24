 c#
class Whatever {
    private Whatever(...) { ... } // basic ctor
    private async ValueTask InitAsync(...) { ... } // async part of ctor
    public static async ValueTask<Whatever> CreateAsync(...) {
        var obj = new Whatever(...);
        await obj.InitAsync(...);
        return obj;
    }
}
