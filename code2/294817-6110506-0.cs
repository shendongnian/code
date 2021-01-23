    class FactoryA {
        void setFactoryB(FactoryB factoryB) { /* sets into state */ }
        EntityA create(Enum type) {
            EntityA entityA = new EntityA();
            /* DI FactoryB - this method is probably default access */
            entityA.setFactoryB(getFactoryB());
        }
    }
    class FactoryB {}
